<?php
    if(isset($_POST["email"]) &&
        isset($_POST["username"]) && 
        isset($_POST["password"])
        ) {
		$errors = array();
		
		$email = strtolower($_POST["email"]);
		$username = strtolower($_POST["username"]);
		$password = $_POST["password"];
		
		//Check if there is user already registered with the same email or username
		if(count($errors) == 0){
			//Connect to database
			require dirname(__FILE__) . '/config.php';
			
			if ($stmt = $mysqli_conection->prepare("SELECT username, email FROM users WHERE email = ? OR username = ? LIMIT 1")) {
				
				/* bind parameters for markers */
				$stmt->bind_param('ss', $email, $username);
					
				/* execute query */
				if($stmt->execute()){
					
					/* store result */
					$stmt->store_result();

					if($stmt->num_rows > 0){
					
						/* bind result variables */
						$stmt->bind_result($username_tmp, $email_tmp);

						/* fetch value */
						$stmt->fetch();
						
						if($email_tmp == $email){
							$errors[] = "User with this email already exist.";
						}
						else if($username_tmp == $username){
							$errors[] = "User with this name already exist.";
						}
                    }
                    
                    if ($stmt1 = $mysqli_conection->prepare("CREATE TABLE {$username}_notes(id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY, 
                                                                                creation_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                                                                                title TEXT,
                                                                                note_text TEXT)")) {
                        if(!$stmt1->execute()){
                            $errors[] = "Something went wrong, please try again.";
                        }
                    }
					
					/* close statement */
                    $stmt->close();
                    $stmt1->close();
					
				}else{
					$errors[] = "Something went wrong, please try again.";
				}
			}else{
				$errors[] = "Something went wrong, please try again.";
			}
		}
		
		//Finalize registration
		if(count($errors) == 0){
			$hashedPassword = password_hash($password, PASSWORD_BCRYPT);
			if ($stmt = $mysqli_conection->prepare("INSERT INTO users (username, email, password) VALUES(?, ?, ?)")) {
				
				/* bind parameters for markers */
				$stmt->bind_param('sss', $username, $email, $hashedPassword);
					
				/* execute query */
				if($stmt->execute()){
					
					/* close statement */
					$stmt->close();
					
				}else{
					$errors[] = "Something went wrong, please try again.";
				}
			}else{
				$errors[] = "Something went wrong, please try again.";
			}
		}
		
		if(count($errors) > 0){
			echo $errors[0];
		}else{
			echo "Success";
		}
	} else {
		echo "Missing data";
	}
?>