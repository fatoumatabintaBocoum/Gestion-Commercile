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
import javafx.scene.control.Label;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.Node;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Window;

/**
 *
 * @author PC
 */
public class ConnexionController implements Initializable {
    
    @FXML
    private Label label;
    
    @FXML
    private TextField loginField;
    
    @FXML
     private PasswordField passwordField;
    
    @FXML
    private Button submitButton;

    Stage dialogStage = new Stage();
    Scene scene;

    @FXML
    public void login(ActionEvent event) throws SQLException {
        Window owner=submitButton.getScene().getWindow();
        if (textfield.getText().isEmpty()) {
            showAlert(Alert.AlertType.ERROR, owner,"Form Error!",
                "Please enter your email id");
            return;
        }
        if (passwordfield.getText().isEmpty()) {
            showAlert(Alert.AlertType.ERROR, owner, "Form Error!",
                "Please enter a password");
            return;
        }
        String login = textfield.getText();
        String password = passwordfield.getText();
        Jdbc jdbc=new Jdbc();
        jdbc.login(login,password);
        
        showAlert(Alert.AlertType.CONFIRMATION, owner, "user connected!",
            "connected " + textfield.getText());

        Node node = (Node)event.getSource();
        dialogStage = (Stage) node.getScene().getWindow();
        dialogStage.close();
        scene = new Scene(FXMLLoader.load(getClass().getResource("Menu.fxml")));
        dialogStage.setScene(scene);
        dialogStage.show();
        
    }
    
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
