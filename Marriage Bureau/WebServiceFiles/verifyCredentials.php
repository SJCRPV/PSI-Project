<?php
	@include("connection.php");
	
	$username = $_POST['username'];
	$password = $_POST['password'];
	
	$query = "SELECT * 
			  FROM utilizador
			  WHERE '$username' = USERNAME AND '$password' = PASSWORD";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $query);
	
	if(!$result)
	{
		echo "The query failed\n" . mysqli_error($connection);
	}
	
	$rowCount = mysqli_num_rows($result);
	
	if($rowCount == 0)
	{
		echo "false";
	}
	else
	{
		echo "true";
	}
	
?>