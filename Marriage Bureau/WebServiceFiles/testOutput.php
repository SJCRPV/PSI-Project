<?php
	@include("connection.php");
	
	$select = "SELECT * FROM utilizador";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $select);
	
	while($row = mysqli_fetch_array($result))
	{
		echo $row['USERNAME'] . "\n" . $row['PASSWORD'] . "\n";
	}
	
	mysqli_close($connection);
?>