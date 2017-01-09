<?php
	@include("connection.php");
	
	$id = $_POST['id'];
	$username = $_POST['username'];
	$table = 'pessoa';
	
	$select = "SELECT $id FROM $table WHERE username = $username"
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $select);
	
	while($row = mysqli_fetch_array($result))
	{
		echo $row['id'] . "\n";
	}
	
	mysqli_close($connection);
?>