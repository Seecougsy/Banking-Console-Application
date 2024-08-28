using System;
using Classes;

public class UserAccount : BankMethods
{

    string username;
    decimal balance;
    string password;
    // public string email = "";
    // public int age = 0;
    // public int phone = 0;
    // public string password = "";


    public UserAccount(string username, decimal balance, string password)
    {
        this.username = username;
        this.balance = balance;
        this.password = password;
    }

    public string getusername()
    {
        return username;
    }

    public decimal getbalance()
    {
        return balance;
    }

    public string getpassword()
    {
        return password;
    }

    public void setUsername(string newUsername)
    {
        username = newUsername;
    }

    public void setBalance(decimal newBalance)
    {
        balance = newBalance;
    }

    public void setPassword(string newPassword)
    {
        password = newPassword;
    }















}