<?php
	if(isset($_POST["username"]) && isset($_POST["password"]) && isset($_POST["note_id"]) && isset($_POST["note_title"]) && isset($_POST["note_text"])){
		$errors = array();
		
		$username = $_POST["username"];
        $password = $_POST["password"];
        $note_id = $_POST["note_id"];
        $note_title = $_POST["note_title"];
        $note_text = $_POST["note_text"];
		
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

                        $sqlEditNote = "UPDATE {$username}_notes SET title=?, note_text=? WHERE id=?";
                       
                        $stmt = $mysqli_conection->prepare("UPDATE {$username}_notes SET title=?, note_text=? WHERE id=?");
                        $stmt->bind_param('sss', $note_title, $note_text, $note_id);
                    
                        if(!$stmt->execute()) {
                            echo "Error: " . $resultDeleteNote . "<br>" . $mysqli_conection->error;
                        }

                        echo "Success";

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