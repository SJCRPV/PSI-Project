<?php
	@include("connection.php");

	//Vars sent from Unity
	$name = $_POST['name'];
	$email = $_POST['email'];
	$username = $_POST['username'];
	$password = $_POST['password'];
	
	//Queries
	$insert = "INSERT INTO pessoa (USERNAME, EMAIL, NOMECOMPLETO)
			   VALUES('$username', '$email', '$name')";
	$insert2 = "INSERT INTO utilizador (USERNAME, PASSWORD)
				VALUES('$username', '$password')";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $insert2);
	
	if(!$result)
	{
		echo "The query failed.\n" . mysqli_error($connection);
	}
	
	$result = mysqli_query($connection, $insert);
	
	if(!$result)
	{
		echo "The query 2 failed.\n" . mysqli_error($connection);
	}
	mysqli_close($connection);
?>