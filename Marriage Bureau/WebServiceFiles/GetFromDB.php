<?php
	@include("connection.php");

	$postCount = count($_POST);
	if($postCount > 2)
	{
		for($i = 0; $i < $postCount - 1; $i++)
		{
			$aggregate += $_POST[(string)$i)];
		}
		$tableName = $_POST[(string)($postCount - 1)];
	}
	else
	{
		$aggregate = $_POST[0];
		$tableName = $_POST[1];
	}
	
	$select = "SELECT $aggregate FROM $tableName";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $select);
	
	while($row = mysqli_fetch_array($result))
	{
		echo $row['Name'] . " : " . $row['Email'] . " : " . $row['Username'] . " : " . $row['Password'] . "\n";
	}
	
	mysqli_close($connection);
?>