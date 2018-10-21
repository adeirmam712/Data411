<?php
include "koneksi.php";

$id =$_POST['id'];
$name =$_POST['nama'];
$kat=$_POST['p'];
$har =$_POST['Harga'];
$namafile = $_FILES['gambar']['name'];
$namasementara = $_FILES['gambar']['tmp_name'];
$dirupload = "gambar/.$namafile";

$terupload = move_uploaded_file($namasementara,$dirupload.$namafile);
$gambar = "gambar/".$namafile;
$query="UPDATE tabel_produk SET Nama_produk='$name',Kategori_id='$kat',harga='$har',Foto_produk='$gambar' WHERE Kode_produk='$id'";
mysql_query($query);
header("location:List.php");
?>

