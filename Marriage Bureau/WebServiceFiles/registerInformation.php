<?php
	@include("connection.php");

	$altura = $_POST['altura'];
	$etnia = $_POST['etnia'];
	$musica = $_POST['musica'];
	$idolos = $_POST['idolos'];
	$filmes = $_POST['filmes'];
	$profissao = $_POST['profissao'];
	$corPreferida = $_POST['corPreferida'];
	$olhos = $_POST['olhos'];
	$corCabelo = $_POST['corCabelo'];
	$filhos = $_POST['filhos'];
	$defeitos = $_POST['defeitos'];
	$tracos = $_POST['tracos'];
	$importante = $_POST['importante'];
	$animais = $_POST['animais'];
	
	$username = $_POST['username'];
	$temposLivres = $_POST['temposLivres'];
	$idade = $_POST['idade'];
	
	$connection = mysqli_connect($server, $DBusername, $DBpassword, $database);
	
	$insertToCP = "INSERT INTO caracteristicaspessoais
				  values('$olhos', '$etnia', '$corCabelo', '$altura', '$profissao', '$corPreferida', '$filhos', '$animais', '$importante', '$tracos', '$defeitos', '$musica', '$idolos', '$filmes')";
				  
	$result = mysqli_query($connection, $insertToCP);
	if(!$result)
	{
		echo "insertToCP failed.\n" . mysqli_error($connection);
	}
	
	$selectCPID = "SELECT LAST(IDCPESSOAIS)
					FROM caracteristicaspessoais";
	$CPID = mysqli_query($connection, $selectCPID);
	if(!$CPID)
	{
		echo "CPID failed.\n" . mysqli_error($connection);
	}
	
	$selectID = "SELECT IDPESSOA
				FROM pessoa
				WHERE USERNAME = '$username'" ;
	$result = mysqli_query($connection, $selectID);
	if(!$result)
	{
		echo "selectID failed.\n" . mysqli_error($connection);
	}
	
	$insertToTemc = "INSERT INTO temc
					values('$selectID', '$CPID')";
	if(!$result)
	{
		echo "insertToTemc failed.\n" . mysqli_error($connection);
	}
					
	$updateInPessoa = "UPDATE pessoa
					   SET IDADE = '$idade'
					   WHERE USERNAME = '$username'";
	
	$result = mysqli_query($connection, $updateInPessoa);
	if(!$result)
	{
		echo "updateInPessoa failed.\n" . mysqli_error($connection);
	}
?>