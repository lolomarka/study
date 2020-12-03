using Xunit;
using OOPlab9;
using System;

public class TestTriangleArray
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


    [Fact]
    public void TriangleArrayConstructorWithParamsRND()
    {
        int len = 5;
        Random rnd = new Random(0);
        Random rnd1 = new Random(0);
        var Arr = new TriangleArray(len,rnd);

        
        Triangle[] triarr = new Triangle[len];

        for(int i = 0; i < len;i++)
        {
            double a, b , c;

            a = Math.Abs((double) rnd1.Next(64,255) / (double) rnd1.Next(1,32));
            b = Math.Abs((double) rnd1.Next(64,255) / (double) rnd1.Next(1,32));
            c = Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));

            triarr[i] = new Triangle(a,b,c);
        }

        //для чистоты эксперимента
        triarr[0].SetInstanceToZero();

        Assert.Equal(len,Arr.length);
        for(int i = 0; i < len; i++)
        {
            Assert.Equal(triarr[i].GetInformationToString, Arr[i].GetInformationToString);
        }

        
    }


    [Fact]
    public void TriangleArrayConstructorWithParamsMan()
    {
        int len = 5;

        var triarr = new TriangleArray(len);

        Triangle[] arrTRI = new Triangle[len];

        for(int i = 0; i < len;i++)
        {
            arrTRI[i] = new Triangle();
        }

        
        Assert.Equal(len,triarr.length);
        for(int i = 0; i< len;i++)
        {
            arrTRI[0].SetInstanceToZero();
            Assert.Equal(arrTRI[i].GetInformationToString, triarr[i].GetInformationToString);
            arrTRI[0].SetInstanceToZero();
        }
    }

    
    [Fact]
    public void TriangleArrayIndexSetTest()
    {
        int len = 1;

        Triangle[] triArr = new Triangle[len];

        TriangleArray triArrTesting = new TriangleArray(len,new Random(0));

        triArr[0] = new Triangle();
        triArrTesting[0] = new Triangle();

        triArr[0].SetInstanceToZero();

        Assert.Equal(triArr[0].GetInformationToString, triArrTesting[0].GetInformationToString);
    }

    [Fact]
    public void TriangleArrayShowTest()
    {
        Random rnd = new Random(0);
        Random rndExp = new Random(0);

        int len = 3;
        Triangle[] tri = new Triangle[len];
        TriangleArray triArrTest = new TriangleArray(len,rnd);

        for(int i = 0; i < len;i++)
        {
            double a, b , c;

            a = Math.Abs((double) rndExp.Next(64,255) / (double) rndExp.Next(1,32));
            b = Math.Abs((double) rndExp.Next(64,255) / (double) rndExp.Next(1,32));
            c = Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));

            tri[i] = new Triangle(a,b,c);
        }

        
        //для чистоты эксперимента
        tri[0].SetInstanceToZero();
        
        string strExp = "";

        for(int i = 0; i < len;i++)
        {
            strExp += $"Элемент №{i+1}:\n{tri[i].GetInformationToString}\t";
        }

        Assert.Equal(strExp,triArrTest.Show());

    }

    [Fact]
    public void TriangleArrayFindMinimalArea()
    {
        Random rnd = new Random(0);
        Random rndExp = new Random(0);

        int len = 1;
        Triangle[] tri = new Triangle[len];
        TriangleArray triArrTest = new TriangleArray(len,rnd);

        for(int i = 0; i < len;i++)
        {
            double a, b , c;

            a = Math.Abs((double) rndExp.Next(64,255) / (double) rndExp.Next(1,32));
            b = Math.Abs((double) rndExp.Next(64,255) / (double) rndExp.Next(1,32));
            c = Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));

            tri[i] = new Triangle(a,b,c);
        }

        Assert.Equal(0,triArrTest.GetMinimalTriangle());
    }
}