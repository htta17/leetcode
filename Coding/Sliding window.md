- Given an integer array and a window of size w, find the current maximum value in the window as it slides through the entire array.
```javascript
export function findMaxSlidingWindow(nums, w) {
    // your code will replace this placeholder return statement
    var ans = [];
    var sWindow = []; //sWindow to save index of max and 2nd max of current window (maxLength of sWindow is 2)
    for (var i=0; i< nums.length; i++) {
        //pos: The position for answer 
        var pos = i - w + 1; 
        pos = pos < 0 ? 0 : pos; 
        
        //Remove current pos of sWindow if sWindow keep any position out of windows (pos to i)
        if (sWindow.length == 2 && sWindow[1] < pos) {
            sWindow.length = 1; //Remove sWindows[1]
        }
        if (sWindow.length && sWindow[0] < pos) {
            sWindow = sWindow.slice(1); //Remove sWindow[0], remaining can be empty or have 1 item
        }
        
        if (sWindow.length == 0) {
            sWindow.push(i); 
            ans[pos] = nums[i];
        }
        else {//sWindow.length == 1 || sWindow.length == 2
            if (nums[i] >= nums[sWindow[0]]) {
                //Save sWindows[0]
                sWindow[1] = sWindow[0]; 
                //Push i into sWindows[0]
                sWindow[0] = i; 
            }
            else if (sWindow.length == 1 || (sWindow.length == 2 && nums[i] > sWindow[1])) {
                sWindow[1] = i;
            }
        }
        ans[pos] = nums[sWindow[0]];
    }
    return ans;
}
```

- Best Time to Buy and Sell Stock. <br/>
Given an array where the element at the index i represents the price of a stock on day <code>i</code>, find the maximum profit that you can gain by buying the stock <i><b>once</b></i> and then selling it.


```javascript
export function maxProfit(array) {
    // Your code will replace this placeholder return statement.
    //Concept: 
    //    Assume we buy first stock (min = array[0]), 
    //    Loop from 1--> array.length - 1, 
    //              try to sell it with current price, means profit is (array[i] - min)
    //              meanwhile, we update min if min still greater than array[i]

    var maxProfit = 0 ; 
    var min = array[0]; 
    for (var i=1; i< array.length; i++) {
        if (maxProfit < array[i] - min) 
            maxProfit = array[i] - min;        
        if (min > array[i]) 
            min = array[i];        
    }
    return maxProfit;
}

```
