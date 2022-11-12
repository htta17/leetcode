def max_profit(stock_prices):
    profit = 0
    l = 0
    min_price = float('inf')
    for r in range(len(stock_prices)):
        if stock_prices[r] < min_price:
            min_price = stock_prices[r]
            l = r
        profit = max(profit, stock_prices[r] - min_price)
    return 0 if profit <= 0 else profit
