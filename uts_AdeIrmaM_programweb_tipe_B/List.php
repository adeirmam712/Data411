<?php include "koneksi.php";?>
<div class="container">
  <center><h2>Apa itu Tabel ?</h2>
  <p></p>                                                                                      
         </center>
  <table width=85% border="3" align="center">
    <thead>
      <tr>
        <th >No</th>
        <th>nama barang</th>
		<th>kategori id</th>
        <th>harga</th>
        <th>gambar </th>
		<th>Aksi kita </th>
      </tr>
    </thead>
    <tbody>
	
	<?php 
	$query = "select * from tabel_produk";
	$res = mysql_query($query);
	$no=1;
	while($row=mysql_fetch_array($res)){
	?>
      <tr>
        <td align="center"><?php echo $row['Kode_produk'];?></td>
        <td align="center"><?php echo $row['Nama_produk'];?> </td>
		<td align="center"><?php echo $row['Kategori_id'];?> </td>
		<td align="center"><?php echo $row['harga'];?> </td>
        <td><img src="<?php echo $row['Foto_produk'];?>" width="80" </td>
        <td align="center"><a href="edit.php?mod=produk_form&id=<?php echo $row['Kode_produk'];?>"> edit</a> |<a href="deleteform.php?mod=produk_form &id=<?php echo $row['Kode_produk'];?>"> delete</a></td>
      </tr>
	<?php } ?>
	
	
    </tbody>
  </table><br><center>
  <button><a href="index.php">back</a></button>  </center>
  </div>
</div>