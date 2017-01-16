<?php
	@include("connection.php");
	
	$receiver = $_POST['receiver'];	
	$table = 'notificacoes';
	
	$select = "SELECT USERNAME, TEMPO, DESCRICAO, VISTA FROM $table WHERE USERNAME_RECEIVER = $receiver";
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $select);
	
	while($row = mysqli_fetch_array($result))
	{
		echo $row['USERNAME'] . ";" . $row['TEMPO'] . ";" . $row['DESCRICAO'] . ";" . $row['VISTA'] . ",";
	}
	
	mysqli_close($connection);
?>