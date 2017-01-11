<?php
	@include("connection.php");
	
	$id = $_POST['id'];	
	$table = 'pessoa';
	
	$select = "SELECT IDPESSOA FROM $table WHERE $id = IDPESSOA";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $select);
	
	while($row = mysqli_fetch_array($result))
	{
		echo $row['IDPESSOA'];
	}
	
	mysqli_close($connection);
?>