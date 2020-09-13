<?php
	if(isset($_GET["username"]) && isset($_GET["password"])){
		$errors = array();
		
		$username = $_GET["username"];
		$password = $_GET["password"];
		
		//Connect to database
		require dirname(__FILE__) . '/config.php';
		
		if ($stmt = $mysqli_conection->prepare("SELECT username, email, password FROM users WHERE username = ? LIMIT 1")) {
			
			/* bind parameters for markers */
			$stmt->bind_param('s', $username);
				
			/* execute query */
			if($stmt->execute()){
				
				/* store result */
				$stmt->store_result();

				if($stmt->num_rows > 0){
					/* bind result variables */
					$stmt->bind_result($username_tmp, $email_tmp, $password_hash);

					/* fetch value */
					$stmt->fetch();
					
					if(password_verify ($password, $password_hash)){
                        echo "Success";
                        
                        // Get User Notes
                        $result = $mysqli_conection->query("SELECT * FROM {$username}_notes");

                        $notes = array();
                        while ( $row = $result->fetch_assoc())  {
                            $notes[]=$row;
                        }

                        echo json_encode($notes);

						return;
					}else{
						$errors[] = "Wrong username or password.";
					}
				}else{
					$errors[] = "Wrong username or password.";
				}
				
				/* close statement */
                $stmt->close();
                
				
			}else{
				$errors[] = "Something went wrong, please try again.";
			}
		}else{
			$errors[] = "Something went wrong, please try again.";
		}
		
		if(count($errors) > 0){
            echo $errors[0];
		}
	}else{
        echo "Missing data";
	}
?>