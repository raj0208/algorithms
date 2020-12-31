# System design | Back of envelop calculations for storage, memory, bandwidth, traffic etc.

During system design interviews, its a good idea to do some quick calculations with few assumptions to plan for scalability, storage, bandwidth etc. Generally these calculations or estimations are referred to as “Back Of Envelope” calculations or estimations.

In this article, we will list out some basic assumptions & understand how we can calculate further using those assumptions. Assumptions in this article are just a design starter & might not match exactly with real world applications. But these are generally good enough assumptions to start interview conversation & get rough idea of system. This shows that you have basic sizing in mind.

# Considerations

Back of envelope calculations are supposed to be rough & approximate.
Don’t try to get too much into detailed calculations. Roundup numbers if needed.
Keep assumption numbers easy to quickly calculate like 200 KB or 500 million users etc. Don’t try to look up real numbers & go odd or too specific like 187 KB or 324 million users etc. This will make calculations harder & interviewers might not be expecting too specific.
After putting your assumptions, always verify with interviewer if they want to adjust assumptions with what they have in mind. This shows that you are doing cross verification & willing to adjust scale per actual need.
Basic calculations to remember:
x KB * y Million users = xy GB (Ex: 1 KB data (1000 bytes) * 1 million user (1,000,000) = 1,000,000,000 = 1 GB of storage)
x MB * y Million users = xy TB

# Assumptions

In this sections you will get some size/number assumptions for doing back of envelop calculations. Again these might not match real world applications. If you have better idea about any numbers/size, then feel free to replace you number/size & do further calculations.


# Storage Assumptions

General assumption for data to be stored.

Single Char  = 2 bytes.
Long or double = 8 bytes.
Image or photo
Average photos = 200 KB
Good photos = 2 MB
Videos
Average 2 MB in posts etc.,
Standard videos for streaming = 50 MB per minute of video
Examples:

Social media: twit or post can be assumed 140 char then 140*2 bytes = 280 bytes per post/twit.
Tiny URL: Average URL length <100 char. Longer URLs needing tiny URL will generally be more than 150 char, lets say 200 char. then each URL assume as 200*2 = 400 bytes
Database id or price etc field can be double or long so 8 bytes per field.
Traffic Assumptions

Social Media (Facebook, Instagram, Twitter) or Chat application (WhatsApp, Facebook Messenger):
Large social media application: 1 billion total users, 500 million daily active users.
Normal social media application: 500 million total users, 200 million daily active users
Video streaming applications (YouTube, Netflix, Hulu):
1 billion total users, 800 million daily active users.
Cloud or file storage applications (Google Drive, Dropbox, Microsoft OneDrive)
Large – 1 billion total users, 500 million daily active users
Normal – 500 million total users, 100 million daily active users
Time Assumptions

Below are some time related assumptions which are approximated to make it easy to calculate without calculator.

Count of Days in 5 year =  365 days * 5 year = 1825 days = 2000 days (Approximate)
Seconds in a day = 24 hours × 60 minutes × 60 seconds =86,400 seconds =  100,000 seconds (Approximate)
Calculations

In this calculations, we will go through doing calculations for a social media application using above assumptions.

Social Media Calculations:

Assumptions (As per above sections)
Assume Post or tweet is 140 character. So size = 140 char * 2 byte char = 280 bytes = Approximate to 300 bytes for ease of calculations
Let’s assume 1 billion total users, 500 million daily active users. So 500 million users post single twit or post daily.
Assume 10 million users post photos average size 200 KB
Total storage per day
Text data storage: 300 bytes * 500,000,000 = 150,000,000,000 = 150 GB of twit or post data per day.
Photo storage: 200 KB * 10,000,000 = 2,000 GB = 2 TB

5 year worth storage

Days in 5 year = 2000 days approximate (As per above sections)
150 GB per day text data * 2000 days = 300,000 = 300 TB
2 TB per day images * 2000 days = 4,000 TB

# Bandwidth

Seconds in days = 100,000 seconds approximate (As per above sections)
150 GB per day / 100,000 seconds = 150,000,000,000 / 100,000 = 1,500,000 = 1.5 MB per second
2 TB per day / 100,000 seconds = 2,000,000,000,000 / 100,000 = 200,000,000 bytes per second = 200 MB per second

# Memory / Cache

If we want to cache per user 20 posts/twits then 300 bytes * 500,000,000 daily users * 20 = 150 GB * 20 = 3000 GB = 3 TB of cache.
If one machine or server can keep 150 GB of cache, then need 20 machines / servers for caching.

# Database size calculations

This is an example for single table. As per your design you can do similar quick calculations for all tables to get rough idea about database storage.

Example of User table

User_id = 8 byte double
User_name = 200 bytes (10 char * 2 bytes)
email_id = 100 bytes (50 char * 2 bytes)
So each row = 8 + 200 + 100 = 308 bytes = 300 bytes approximate

1 billion Users * 300 bytes = 1,000,000,000 * 300 = 300,000,000,000 = 300 GB
