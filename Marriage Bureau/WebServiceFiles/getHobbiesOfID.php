<?php
	@include("connection.php");
	
	$idPessoa = $_POST['id'];
	
	$procuraQuery = "SELECT * FROM procurap WHERE IDPESSOA = $idPessoa"
	$fullProcuraQuery = "SELECT TEMPOSLIVRES FROM passatempos WHERE IDTEMPOSLIVRES in ($procuraQuery)"
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$procuraResult = mysqli_query($connection, $fullProcuraQuery);
	
	while($row = mysqli_fetch_array($procuraResult))
	{
		echo $row['TEMPOSLIVRES'] . ",";
	}
?>