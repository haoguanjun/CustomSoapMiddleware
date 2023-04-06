using System.ServiceModel;

[ServiceContract]
public interface ICalculatorService
{
    [OperationContract] double Add(double x, double y);
    [OperationContract] double Subtract(double x, double y);
    [OperationContract] double Multiply(double x, double y);
    [OperationContract] double Divide(double x, double y);
}