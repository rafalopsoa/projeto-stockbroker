namespace StockBroker.Domain.Enums;

public enum OrderSide { Buy, Sell }
public enum OperationStrategy { Position, DayTrade }
public enum TimeInForce { Day, GoodTillDate, GoodTillCancel, ImmediateOrCancel, FillOrKill}
public enum OrderStatus { Pending, Executed, Open, Canceled, Rejected }