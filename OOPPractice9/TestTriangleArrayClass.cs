using Xunit;
using OOPPractice9;
using System;

public class TestTriangleArrayClass
{
    
    [Fact]
    public void TriangleArrayConstructorWithoutParams()
    {
        var arrExp = new Triangle[0];
        int lengthExp = 0;

        TriangleArray triArr = new TriangleArray();

        Assert.Equal(arrExp,triArr.arr);
        Assert.Equal(lengthExp, triArr.length);
    }


    
}