<?php
	@include("connection.php");
	
	$username = $_POST['username'];	
	$table = 'notificacoes';
	
	$select = "SELECT TEMPO, DESCRICAO, VISTA FROM $table WHERE USERNAME = $username";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $select);
	
	while($row = mysqli_fetch_array($result))
	{
		echo $row['TEMPO'] . "," . $row['DESCRICAO'] . "," . $row['VISTA'] . ";";
	}
	
	mysqli_close($connection);
?>