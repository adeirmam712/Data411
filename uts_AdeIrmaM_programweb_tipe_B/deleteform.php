<?php
include"koneksi.php";
$id=$_GET['id'];
$query="delete from tabel_produk where Kode_produk='$id'";
mysql_query($query);
header("location:List.php");



?>