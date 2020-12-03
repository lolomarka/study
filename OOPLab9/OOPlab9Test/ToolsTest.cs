using Xunit;
using OOPlab9;
using System;

public class ToolsTest
{
    
    [Theory]
    [InlineData("0", 0)]
    [InlineData("5", 5)]
    public void InputNumIntTestGoodInput(string testLine, int inputExp)
    {
        console cnsl = new console(testLine);


        int input = Tools.InputNumInt("","");

        Assert.Equal(inputExp,input);
    }

    [Theory]
    [InlineData("-123!asexc1q@#")]
    [InlineData("aaa")]
    [InlineData("")]
    public void InputNumIntTestBadInput(string testLine)
    {
        console cnsl = new console(testLine);

        
        int a = 255;
        
        a = Tools.InputNumInt();
        //Если ошибка прокидывается, то а = 0.
        
        Assert.Equal( 0,a);
    }


    


    [Theory]
    [InlineData("21,5", 21.5)]
    [InlineData("555", 555)]
    public void InputAbsNumDoubleTestGoodInput(string doubleString, double valExp)
    {
        console cnsl = new console(doubleString);

        double result = Tools.InputAbsNumDouble();

        Assert.Equal(valExp,result);

    }

    [Theory]
    [InlineData("-21,5", 0)]
    [InlineData("21.5", 0)]
    [InlineData("asdsadfgas", 0)]
    [InlineData("", 0)]
    public void InputAbsNumDoubleTestBadInput(string doubleString, double valExp)
    {
        console cnsl = new console(doubleString);

        double result = Tools.InputAbsNumDouble();

        Assert.Equal(valExp,result);

    }


    [Theory]
    [InlineData("21,5", 21.5)]
    [InlineData("-21,5", -21.5)]
    [InlineData("555", 555)]
    public void InputNumDoubleTestGoodInput(string doubleString, double valExp)
    {
        console cnsl = new console(doubleString);

        double result = Tools.InputNumDouble();

        Assert.Equal(valExp,result);

    }

    [Theory]
    [InlineData("21.5", 0)]
    [InlineData("asdsadfgas", 0)]
    [InlineData("", 0)]
    public void InputNumDoubleTestBadInput(string doubleString, double valExp)
    {
        console cnsl = new console(doubleString);

        double result = Tools.InputNumDouble();

        Assert.Equal(valExp,result);

    }
    

    [Theory]
    [InlineData("2", 2)]
    [InlineData("52", 52)]
    [InlineData("5221", 5221)]
    public void InputNumOfElementsTestGoodInput(string testLine, int inputExp)
    {
        console cnsl = new console(testLine);

        int result = Tools.InputNumOfElements();
        

        Assert.Equal(inputExp,result);
    }

    [Theory]
    [InlineData("-2", 0)]
    [InlineData("aaaa", 0)]
    [InlineData("", 0)]
    public void InputNumOfElementsTestBadInput(string testLine, int inputExp)
    {
        console cnsl = new console(testLine);

        int result = Tools.InputNumOfElements();
        


        //Если вернёт 0, то значит функция работает правильно
        Assert.Equal(inputExp,result);
    }

}