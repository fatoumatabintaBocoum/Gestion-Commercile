package gestion_com.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

/**
 *
 * @author PC
 */
public class Jdbc {
  
    private static final String DATABASE_URL = "jdbc:mysql://localhost:3306/gestion_com?useSSL=false";
    private static final String DATABASE_USERNAME = "root";
    private static final String DATABASE_PASSWORD = "";
    private static final String INSERT_QUERY = "";
    Connection connection = DriverManager.getConnection(DATABASE_URL, DATABASE_USERNAME, DATABASE_PASSWORD);
   
    public void inscription(String nomField, String prenomField, String profilfield, String emailField, String passwordField, String profilField) throws SQLException {

        INSERT_QUERY = "INSERT INTO user (nom, prenom, login, password, id_profil) VALUES (?, ?, ?, ?, ?)";
        try (PreparedStatement preparedStatement = connection.prepareStatement(INSERT_QUERY))
        {
            preparedStatement.setString(1, nomField);
            preparedStatement.setString(2, prenomField);
            preparedStatement.setString(3, emailField);
            preparedStatement.setString(4, passwordField);
            preparedStatement.setString(5, profilField);
            System.out.println(preparedStatement);
            preparedStatement.executeUpdate();
        } catch (SQLException e) {
            
            printSQLException(e);
        }
    }
    
    public ResultSet listUser()
    {
       INSERT_QUERY = "SELECT * FROM user";
        try (PreparedStatement preparedStatement = connection.prepareStatement(INSERT_QUERY))
        {
            System.out.println(preparedStatement);
            ResultSet rs=preparedStatement.executeQuery();  
        } catch (SQLException e) {
            
            printSQLException(e);
        }

        return rs;
    }

    public void login(String emailField, String passwordField) throws SQLException {

         INSERT_QUERY = "SELECT * FROM user WHERE email = ? and password = ?";
        try (
            Connection connection = DriverManager.getConnection(DATABASE_URL, DATABASE_USERNAME, DATABASE_PASSWORD);
            PreparedStatement preparedStatement = connection.prepareStatement(INSERT_QUERY)) {
                preparedStatement.setString(1, emailField);
                preparedStatement.setString(4, passwordField);
                System.out.println(preparedStatement);
                preparedStatement.executeQuery();
        } catch (SQLException e) {
            
            printSQLException(e);
        }
    }

    private void printSQLException(SQLException e) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
