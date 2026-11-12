<?= $this->extend('layout') ?>

<?= $this->section('content') ?>
<div class="d-flex justify-content-between align-items-center mb-3">
    <h3 class="mb-0">Daftar Mahasiswa</h3>
    <a href="<?= base_url('mahasiswa/create') ?>" class="btn btn-primary">+ Tambah</a>
</div>

<form method="get" class="mb-3">
    <div class="input-group">
        <input type="text" name="q" class="form-control" placeholder="Cari NIM / nama / prodi" value="<?= esc($keyword ?? '') ?>">
        <button class="btn btn-outline-secondary">Cari</button>
    </div>
</form>

<div class="table-responsive">
    <table class="table table-bordered table-striped bg-white">
        <thead class="table-light">
            <tr>
                <th>No</th><th>NIM</th><th>Nama</th><th>Prodi</th><th>Angkatan</th><th>Email</th><th>Aksi</th>
            </tr>
        </thead>
        <tbody>
        <?php if (empty($mahasiswa)): ?>
            <tr><td colspan="7" class="text-center text-muted">Belum ada data.</td></tr>
        <?php endif; ?>

        <?php foreach ($mahasiswa as $i => $m): ?>
            <tr>
                <td><?= $i + 1 + (($pager->getCurrentPage() - 1) * $pager->getPerPage()) ?></td>
                <td><?= esc($m['nim']) ?></td>
                <td><?= esc($m['nama']) ?></td>
                <td><?= esc($m['prodi']) ?></td>
                <td><?= esc($m['angkatan']) ?></td>
                <td><?= esc($m['email']) ?></td>
                <td class="text-nowrap">
                    <a href="<?= base_url('mahasiswa/edit/' . $m['id']) ?>" class="btn btn-sm btn-warning">Ubah</a>
                    <form action="<?= base_url('mahasiswa/delete/' . $m['id']) ?>" method="post" class="d-inline"
                          onsubmit="return confirm('Hapus data ini?')">
                        <?= csrf_field() ?>
                        <button class="btn btn-sm btn-danger">Hapus</button>
                    </form>
                </td>
            </tr>
        <?php endforeach; ?>
        </tbody>
    </table>
</div>

<?php if ($pager->getPageCount() > 1): ?>
    <?= $pager->links() ?>
<?php endif; ?>

<?= $this->endSection() ?>