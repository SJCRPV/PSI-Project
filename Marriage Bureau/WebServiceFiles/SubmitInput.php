<?php
	@include("connection.php");

	//Vars sent from Unity
	$name = $_POST['name'];
	$email = $_POST['email'];
	$username = $_POST['username'];
	$password = $_POST['password'];
	$table = $_POST['pessoa'];
	
	//Queries
	$insert = "INSERT INTO $table (NOMECOMPLETO, EMAIL, USERNAME, Password)
			   VALUES('$name', '$email', '$username', '$password')";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $insert);
	
	while($row = mysqli_fetch_array($result))
	{
		echo $row['Name'] . " : " . $row['Email'] . " : " . $row['Username'] . " : " . $row['Password'] . "\n";
	}
	
	mysqli_close($connection);
?>