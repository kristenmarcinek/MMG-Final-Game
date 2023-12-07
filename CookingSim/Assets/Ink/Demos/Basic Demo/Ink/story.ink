Buffer

Welcome to Suburbia. 

You are many things. 

A loving wife.

A caring mother.

And, most importantly, an exemplary chef.

A homemaker through and through.

A happy homemaker at that.

You are happy, right?

*[Right.]

That's what I thought.

Today is Thursday.

Your husband is at work.

Your kids are at school.

You have the whole day to yourself and an empty house at your disposal.

There are just a few things on your to-do list.

But once you finish everything you need to, you will have the rest of the day to yourself!

Let's run through the to-do list. -> ToDoList

=== ToDoList ===

VAR madeBed = false
VAR doneDishes = false
VAR doneHusbandLaundry = false
VAR doneKB = false
VAR allChoresDone = false
VAR dog = false
VAR kLaundry = false

Have you...
{madeBed:
    *[Gone grocery shopping?] Yes.
    ~ doneKB = true
     -> ToDoList
  - else:
    *[Made your bed?] Yes.
    ~ madeBed = true
    -> ToDoList
    }

 {doneDishes:
    *[Walked the dog?] Yes.
    ~ dog = true
    -> ToDoList
  - else:
    *[Cleaned up breakfast?] Yes.
    ~ doneDishes = true
    -> ToDoList
}
       {doneHusbandLaundry:
    *[Done your kids' laundry?] Yes.
    ~ kLaundry = true
    -> ToDoList
  - else:
    *[Made your husband's doctor appointment?] Yes.
    ~ doneHusbandLaundry = true
    -> ToDoList
}

{madeBed && doneDishes && doneHusbandLaundry && doneKB && dog && kLaundry:
*[Wait-! That's everything! Time to relax!]
-> 5PM
}


=== 5PM ===

5:00PM already?

Time to start dinner!

At least you enjoy cooking.

You found this new recipe for homemade meatballs you've been wanting to try.

Your husband loves pasta. 

You know he had a big presentation today. 

It would be nice to surprise him when he gets home, right?

Let's get started...

- -> END