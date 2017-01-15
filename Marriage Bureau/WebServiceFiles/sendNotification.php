<?php
	@include("connection.php");
	
	$sender = $_POST['sender'];	
	$receiver = $_POST['receiver'];
	$time = time();
	$descricao = $_POST['descricao'];
	$isSeen = $_POST['isSeen'];
	$table = 'notificacoes';
	
	$insert = "INSERT INTO $table
	values($sender, $receiver, $time, $descricao, $isSeen)"
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$result = mysqli_query($connection, $insert);
	
	if(!$result)
	{
		echo "The query failed";
	}
	
	mysqli_close($connection);
?>