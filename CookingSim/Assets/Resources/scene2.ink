EXTERNAL playScene(sceneName)
Buffer

Time flies when you're in the kitchen.

It's one of the few times you actually get some alone time. 

Sure, your husband would help if you asked him to.

But the man can barely hardboil an egg. 

It's much easier and faster for you to just handle it all yourself...

Right?

*[Right.] -> Right


=== Right ===
An hour later and dinner is served right at 6:00 on the dot...

And your husband still isn't home. 

So you wait. -> Wait


=== Wait ===
VAR time = 10


+[Check the clock] It is 6:{time} PM -> Wait
+[Check your phone] { time >= 30: Your sister posted another album of photos from her Carribean cruise on Facebook... still no calls though.}{time < 30: You have 0 missed calls.} -> Wait
+[Wait] You wait. 
~ time = time + 10 

{time < 40: 
-> Wait 
- else: 
-> HusbandHome
}


=== HusbandHome ===

Your husband walks through the door around 6:50.

He greets you with a triumphant grin, seemingly unfazed by the table set for two. 

"I did it!" he exclaims, dropping his bag on the couch as he approaches and gives you a kiss. 

"It went well then?" You ask.

"Better than well-!" You can tell he is about to dive into the finer details of his work day.

"Perhaps this conversation would be best over dinner?" you ask, glancing pointedly at the table set.

"Oh, no thanks honey. It smells delicious, but I already ate. We went out for drinks to celebrate closing the deal!"

Your husband gives you another kiss - this one on the cheek, as he turns to head upstairs. 

"I'm going to hop in the shower!" he calls out, leaving you with your spaghetti dinner for one. 

...The next morning.

You hear an alarm buzzing near your ear. You wake up...

As your eyes slowly open, you think about your day. It's Friday! You know your kids have had a busy school week, maybe you can make a special breakfast to send them off into the last day before their weekend?

*[You grab your phone to turn off the alarm. Since you're already on it, it wouldn't hurt to scroll for a minute, would it?] -> CheckYourPhone

=== CheckYourPhone ===
*[Scroll through Facebook] You take a brief look at Facebook. As you scroll through post after post mindlessly, you come across a cooking video. You pause to see what they're making, and you see some delicious, cheesey omelettes. Your stomach rumbles at the sight. Maybe that would make a good breakfast for the kids! 

~playScene ("Breakfast")

->DONE
*[Check your texts] You haven't gotten any texts yet today. It is only 6 AM.... -> CheckYourPhone


->END
