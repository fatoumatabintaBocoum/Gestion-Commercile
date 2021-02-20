/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package gestion_com;

import gestion_com.dao.Jdbc;
import java.net.URL;
import java.sql.SQLException;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Window;

/**
 * FXML Controller class
 *
 * @author PC
 */
public class InscriptionController implements Initializable {

   
    @FXML
    private Label label;
    
    @FXML
    private TextField nomField;
    
    @FXML
    private TextField prenomField;
    
    @FXML
    private TextField profilField;
    
    @FXML
    private TextField emailField;
    
    @FXML
     private PasswordField passwordField;
    
    @FXML
     private Button submitButton;

    @FXML
    public login(ActionEvent event) throws SQLException {
        Window owner=submitButton.getScene().getWindow();
        if (emailfield.getText().isEmpty()) {
            showAlert(Alert.AlertType.ERROR, owner,"Form Error!",
                "Please enter your email id");
            return;
        }
        if (passwordfield.getText().isEmpty()) {
            showAlert(Alert.AlertType.ERROR, owner, "Form Error!",
                "Please enter a password");
            return;
        }
        String nom = nomField.getText();
        String prenom = prenomField.getText();
        String profil = profilField.getText();
        String login = emailField.getText();
        String password = passwordField.getText();
        Jdbc jdbc=new Jdbc();
        jdbc.inscription(nom, prenom, login, password, profil);
        
        showAlert(Alert.AlertType.CONFIRMATION, owner, "user connected!",
            "connected " + textfield.getText());
        
        return jdbc.listUser();
        
    }

    //@FXML
    //public List<?> listUser()
    
    private static void showAlert(Alert.AlertType alertType, Window owner, String title, String message) {
        Alert alert=new Alert(alertType);
        alert.setTitle(title);
        alert.setHeaderText(null);
        alert.setContentText(message);
        alert.initOwner(owner);
        alert.show();
        
        
        
}
    
    // private void handleButtonAction(ActionEvent event) {
       // System.out.println("You clicked me!");
       // label.setText("Hello World!");
    //}
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
    
}
