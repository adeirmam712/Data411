<?php
include "koneksi.php";

$nama=$_POST['nama'];
$kat=$_POST['p'];
$har=$_POST['Harga'];
$namafile = $_FILES['gambar']['name'];
$namasementara = $_FILES['gambar']['tmp_name'];
$dirupload = "gambar/.$namafile";

$terupload = move_uploaded_file($namasementara,$dirupload.$namafile);
$gambar = "gambar/ .".$namafile;
$produkid = getautoid('Kode_produk','tabel_produk','prd');

$query="INSERT INTO `dbproduk`.`tabel_produk` (`Kode_produk`,`Nama_produk`,`Kategori_id`,`harga`,`Foto_produk`) VALUES ('$produkid','$nama','$kat','$har','$gambar')";

mysql_query($query);

header("location:List.php");





?>
