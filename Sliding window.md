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
