<?= $this->extend('layout') ?>

<?= $this->section('content') ?>
<h3 class="mb-3"><?= esc($title) ?></h3>

<?php if (session()->getFlashdata('errors')): ?>
    <div class="alert alert-danger">
        <ul class="mb-0">
            <?php foreach (session()->getFlashdata('errors') as $err): ?>
                <li><?= esc($err) ?></li>
            <?php endforeach; ?>
        </ul>
    </div>
<?php endif; ?>

<form action="<?= $aksi ?>" method="post" class="card card-body">
    <?= csrf_field() ?>

    <div class="mb-3">
        <label class="form-label">NIM</label>
        <input type="text" name="nim" class="form-control" value="<?= esc(old('nim', $mhs['nim'] ?? '')) ?>" required>
    </div>
    <div class="mb-3">
        <label class="form-label">Nama</label>
        <input type="text" name="nama" class="form-control" value="<?= esc(old('nama', $mhs['nama'] ?? '')) ?>" required>
    </div>
    <div class="mb-3">
        <label class="form-label">Prodi</label>
        <input type="text" name="prodi" class="form-control" value="<?= esc(old('prodi', $mhs['prodi'] ?? '')) ?>" required>
    </div>
    <div class="mb-3">
        <label class="form-label">Angkatan</label>
        <input type="number" name="angkatan" class="form-control" value="<?= esc(old('angkatan', $mhs['angkatan'] ?? '')) ?>" required>
    </div>
    <div class="mb-3">
        <label class="form-label">Email</label>
        <input type="email" name="email" class="form-control" value="<?= esc(old('email', $mhs['email'] ?? '')) ?>">
    </div>

    <div class="d-flex gap-2">
        <button class="btn btn-primary">Simpan</button>
        <a href="<?= base_url('mahasiswa') ?>" class="btn btn-secondary">Batal</a>
    </div>
</form>
<?= $this->endSection() ?>