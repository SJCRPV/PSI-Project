<?php
	@include("connection.php");
	
	$idPessoa = $_POST['id'];
	
	$procuraQuery = "SELECT * FROM procurap WHERE IDPESSOA = $idPessoa"
	$temQuery = "SELECT * FROM temp WHERE IDPESSOA = $idPessoa"
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$procuraResult = mysqli_query($connection, $procuraQuery);
	$temResult = mysqli_query($connection, $temQuery);
	
	while($row = mysqli_fetch_array($procuraResult))
	{
		echo $row['IDTEMPOSLIVRES'] . ",";
	}
?>