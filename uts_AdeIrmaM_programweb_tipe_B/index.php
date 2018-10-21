



<form method="POST" action="produk_add.php" enctype="multipart/form-data"   >
 
      <p>Nama produk <input type="text"  name="nama" size="30" ></p>
		
		<p>kategori<select name="p">
		<?php
			include "koneksi.php";
			$query = "select * from tabel_kategori";
			$hasil = mysql_query($query);
			while ($qtabel = mysql_fetch_assoc($hasil))
			{
				echo '<option value="'.$qtabel['Kategori_id'].'">'.$qtabel['Kategori_desc'].'</option>';				
			}
			?>
		</select></p>
	Harga: 
  <input type="text" name="Harga">
  
  <p>foto:<input type="file" name="gambar">
<br>

<button type="submit" class="btn btn-outline-primary" >Simpan</button>&nbsp;&nbsp;&nbsp;&nbsp;<button> <a href="index.php">Batal</a></button></tr></td>

  </form>
 </table>