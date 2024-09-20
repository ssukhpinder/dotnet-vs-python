## .Net Result
Performance results returned from Apache Bench by calling .Net API running on 5030 on local.
```
D:\httpd-2.4.55-o111s-x86-vs17\Apache24\bin>ab -n 1000 -c 10 http://localhost:5030/factorial?n=10
This is ApacheBench, Version 2.3 <$Revision: 1903618 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 100 requests
Completed 200 requests
Completed 300 requests
Completed 400 requests
Completed 500 requests
Completed 600 requests
Completed 700 requests
Completed 800 requests
Completed 900 requests
Completed 1000 requests
Finished 1000 requests

Server Software:        Kestrel
Server Hostname:        localhost
Server Port:            5030

Document Path:          /factorial?n=10
Document Length:        7 bytes

Concurrency Level:      10
Time taken for tests:   0.184 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      146000 bytes
HTML transferred:       7000 bytes
Requests per second:    5439.01 [#/sec] (mean)
Time per request:       1.839 [ms] (mean)
Time per request:       0.184 [ms] (mean, across all concurrent requests)
Transfer rate:          775.48 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.3      0       5
Processing:     0    2   0.9      2       9
Waiting:        0    1   0.9      1       8
Total:          0    2   0.9      2       9

Percentage of the requests served within a certain time (ms)
  50%      2
  66%      2
  75%      2
  80%      2
  90%      2
  95%      3
  98%      5
  99%      6
 100%      9 (longest request)
```

## Python Result
Performance results returned from Apache Bench by calling Python API running on 8000 on local.
```
D:\httpd-2.4.55-o111s-x86-vs17\Apache24\bin>ab -n 1000 -c 10 http://127.0.0.1:8000/factorial/10
This is ApacheBench, Version 2.3 <$Revision: 1903618 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking 127.0.0.1 (be patient)
Completed 100 requests
Completed 200 requests
Completed 300 requests
Completed 400 requests
Completed 500 requests
Completed 600 requests
Completed 700 requests
Completed 800 requests
Completed 900 requests
Completed 1000 requests
Finished 1000 requests

Server Software:        uvicorn
Server Hostname:        127.0.0.1
Server Port:            8000

Document Path:          /factorial/10
Document Length:        21 bytes

Concurrency Level:      10
Time taken for tests:   0.766 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      165000 bytes
HTML transferred:       21000 bytes
Requests per second:    1305.69 [#/sec] (mean)
Time per request:       7.659 [ms] (mean)
Time per request:       0.766 [ms] (mean, across all concurrent requests)
Transfer rate:          210.39 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.3      0       2
Processing:     3    7   3.6      7      41
Waiting:        2    6   3.5      6      41
Total:          3    8   3.6      7      41

Percentage of the requests served within a certain time (ms)
  50%      7
  66%      8
  75%      8
  80%      8
  90%      9
  95%      9
  98%     11
  99%     38
 100%     41 (longest request)
```
## Comparison
C# (.NET Core with Kestrel)
- Requests per second: 5439.01 [#/sec]
- Time per request (mean): 1.839 ms
- Transfer rate: 775.48 Kbytes/sec
- Connection time (mean): 2 ms
- Longest request time: 9 ms

## Python (FastAPI with Uvicorn)
- Requests per second: 1305.69 [#/sec]
- Time per request (mean): 7.659 ms
- Transfer rate: 210.39 Kbytes/sec
- Connection time (mean): 8 ms
- Longest request time: 41 ms

## Key Observations
### Requests per second
- C#: 5439 requests per second.
- Python: 1305 requests per second.
- C# performs approximately 4 times better in terms of handling requests per second.

### Time per request
- C#: 1.839 ms per request.
- Python: 7.659 ms per request.
- C# responds more than 4 times faster per request compared to Python.

### Transfer rate
- C#: 775.48 KB/sec.
- Python: 210.39 KB/sec.
- C# has a significantly higher transfer rate, meaning it can handle more data throughput.

### Connection times
- C#: Median connection time is 2 ms with the longest request of 9 ms.
- Python: Median connection time is 7 ms with the longest request of 41 ms.
- C# is more efficient in handling individual request connections.

### Consistency
C# shows more consistent performance with minimal deviation, whereas Python shows some spikes, especially in the longest request time (41 ms).

# Conclusion
C# with Kestrel significantly outperforms Python with FastAPI and Uvicorn in this benchmarking test.
- Higher requests per second.
- Lower time per request.
- Better data transfer rate.
- More consistent connection times.

For high-performance applications, especially when handling a large number of concurrent requests, C# provides better performance in this scenario.
