<details>
  <summary>Find the root of items</summary>
  <p>
    Build the funtion to find the root of X with N, means (ans * ans * ... * ans) (N times), will get X. 
    
  </p>

  ```cs
double Calculate(double x, int n) {
    double ans = 1;
    for (int i = 1; i <= n; i++) { 
        ans *= x ;
    }
    return ans;
}
double Root(double x, int n) {
    double left = 0;
    double right = x;
    double mid = (left + right) / 2.0;
    var approximateX = (Calculate(mid, n));
    while (Math.Abs(approximateX - x) > 0.000000001) { 
        var cleft = Calculate(left, n);
        var cright = Calculate(right, n);
        if (cleft > x && cright > x){
            right = left;
            left = left / 2.0;
        }
        else if (cleft < x && cright < x) {
            left = right;
            right = (right + x) / 2;
        }
        else if (approximateX > x) {
            right = mid;        
        }
        else { 
            left = mid;
        }
        mid = (left + right) / 2;
        approximateX = Calculate(mid, n);
    }
    return mid;
}

  ```
</details>
