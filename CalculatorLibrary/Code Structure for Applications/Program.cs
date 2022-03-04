class Account
{
    private String name;
    private String email;
    private String atmPin;
    private String accountNumber;
    private String accountType;
    private decimal accountBalance;

    protected String GetAtmPin()
    {
        //Returns the current ATM Pin
    }
    protected void SetAtmPin(String pin)
    {
        //Sets the ATM Pin to the specified value
    }
    protected decimal GetAccountBalance()
    {
        //Returns the current Account Balance
    }
    protected WithdrawBalance(decimal balanceToBeWithdrawn)
    {
        //Performs all necessary tasks to withdraw money from the account
    }
    protected DepositBalance(decimal balanceToBeDeposited)
    {
        //Performs all necessary tasks to deposit money to the account
    }
}



class ATM : Account
{

    private bool ValidateUserPin()
    {
        //To check if the user has entered correct Pin or not
    }
    private void ChangePin()
    {
        //To change ATM Pin
    }
    private void PrintMiniStatement()
    {
        //To Print MiniStatement
    }
    
    public bool CardInserted()
    {
      //This method will check if Card is inserted or not   
    }
    public void ShowPossibleTransactions()
    {
        //To show the list of all possible transaction a user can perform
        //and to manage the transactions procedure i.e. which function to
        //be invoked and when to be invoked
    }
}