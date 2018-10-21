
<?php 
include"koneksi.php";
	if(isset($_GET['id'])){
	$id = $_GET['id'];
	
	$query = "select * from tabel_produk where Kode_produk='".$id."'";
	$row = mysql_query($query);
	$res = mysql_fetch_array($row);
	$nama = $res['Nama_produk'];
	$har=$res['harga'];
	?>


<form method="POST" action="update.php" enctype="multipart/form-data"   >
		<input type="hidden" name="id" value="<?php echo $id; ?>">
      <p>Nama produk <input type="text"  name="nama" size="30" value="<?php echo $nama?>"></p>
		
		<p>kategori<select name="p">
		<option value="101">Makanan</option>
		<option value="102">Minuman</option>
		<option value="103">Jajanan Ringan</option>
		</select></p>
	Harga: 
  <input type="text" name="Harga"value="<?php echo $har; ?>">
  
  <p>foto:<input type="file" name="gambar">
<br>

<button type="submit" class="btn btn-outline-primary" >update</button>&nbsp;&nbsp;&nbsp;&nbsp;<button> <a href="list.php">Batal</a></button></tr></td>
	</form><?php }?>