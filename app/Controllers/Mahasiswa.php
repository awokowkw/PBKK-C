<?php

namespace App\Controllers;

use App\Models\MahasiswaModel;

class Mahasiswa extends BaseController
{
    protected MahasiswaModel $model;

    public function __construct()
    {
        $this->model = new MahasiswaModel();
    }

    // READ: daftar + pencarian + pagination
    public function index()
    {
        $keyword = $this->request->getGet('q');

        if ($keyword) {
            $this->model->groupStart()
                ->like('nim', $keyword)
                ->orLike('nama', $keyword)
                ->orLike('prodi', $keyword)
                ->groupEnd();
        }

        return view('mahasiswa/index', [
            'title'     => 'Daftar Mahasiswa',
            'mahasiswa' => $this->model->orderBy('nim', 'ASC')->paginate(10),
            'pager'     => $this->model->pager,
            'keyword'   => $keyword,
        ]);
    }

    // CREATE: tampilkan form
    public function create()
    {
        return view('mahasiswa/form', [
            'title' => 'Tambah Mahasiswa',
            'mhs'   => null,
            'aksi'  => base_url('mahasiswa/store'),
        ]);
    }

    // CREATE: simpan data
    public function store()
    {
        $rules = [
            'nim'      => 'required|max_length[20]|is_unique[mahasiswa.nim]',
            'nama'     => 'required|max_length[100]',
            'prodi'    => 'required|max_length[50]',
            'angkatan' => 'required|exact_length[4]|numeric',
            'email'    => 'permit_empty|valid_email',
        ];

        if (! $this->validate($rules)) {
            return redirect()->back()->withInput()
                ->with('errors', $this->validator->getErrors());
        }

        $this->model->insert($this->request->getPost(['nim', 'nama', 'prodi', 'angkatan', 'email']));

        return redirect()->to('/mahasiswa')->with('success', 'Data mahasiswa berhasil ditambahkan.');
    }

    // UPDATE: tampilkan form berisi data lama
    public function edit($id)
    {
        $mhs = $this->model->find($id);

        if (! $mhs) {
            return redirect()->to('/mahasiswa')->with('error', 'Data tidak ditemukan.');
        }

        return view('mahasiswa/form', [
            'title' => 'Ubah Mahasiswa',
            'mhs'   => $mhs,
            'aksi'  => base_url('mahasiswa/update/' . $id),
        ]);
    }

    // UPDATE: simpan perubahan
    public function update($id)
    {
        $rules = [
            'nim'      => "required|max_length[20]|is_unique[mahasiswa.nim,id,{$id}]",
            'nama'     => 'required|max_length[100]',
            'prodi'    => 'required|max_length[50]',
            'angkatan' => 'required|exact_length[4]|numeric',
            'email'    => 'permit_empty|valid_email',
        ];

        if (! $this->validate($rules)) {
            return redirect()->back()->withInput()
                ->with('errors', $this->validator->getErrors());
        }

        $this->model->update($id, $this->request->getPost(['nim', 'nama', 'prodi', 'angkatan', 'email']));

        return redirect()->to('/mahasiswa')->with('success', 'Data mahasiswa berhasil diubah.');
    }

    // DELETE
    public function delete($id)
    {
        $this->model->delete($id);

        return redirect()->to('/mahasiswa')->with('success', 'Data mahasiswa berhasil dihapus.');
    }
}