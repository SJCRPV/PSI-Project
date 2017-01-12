<?php
	@include("connection.php");
	
	$query = "SELECT count(IDPESSOA) as 'Count' FROM pessoas"
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $query);
	
	$row = mysqli_fetch_array($result)
	
	echo $row['Count'];
?>