# Unit Tests in .Net

## setting up the solution
I started by creating a "Library" project name "MegaDesk"
I opted to have it make me a solution folder by the same name.

The MegaDesk library project will make me a DLL with all my business logic for MegaDesk
Then, I add a new project to my solution of type "NUnit Test" named "MegaDesk.Test"
And, I added the DLL project to the Test Project's references.  There are many ways to do this, the easiset of which is to drag the dll project into the "references" folder under the test project

Once the reference is added, the Dll project's classes are visible from the test project (but not vice versa).

Also, since we named the projects the way we did, the MegaDesk.Test files dont need to "Import" MegaDesk, since they are a sub-namespace under MegaDesk.

At this point, since we have no UI layer, you might want to set the test project as the starup project.  (this can be done by right clicking that project and selecting "Set as Startup Project" from the context menu).

## Not testing the UI

Note, I dont intend to test my UI with unit tests.
There are people who do that, but I dont see much point in it.
I test business logic, and I do my best to keep all my "thinking" code out of the UI, so that the UI project is nothing but form interaction (or a website, as the case may be).

the Logic DLL should have everything that wouldnt change if I one day decided to convert the UI to a website or a mobile app, or whatever ... for instance the way desks are priced has nothing to do with what kind of UI I use to interact with my user base, so it belongs in the BI Library, and it should have tests that prove it behaves exactly like the spec requires.

So, validation logic (like desks being within certain sizes, and that material is selected, etc ... that logic belongs here, not in the UI project)

## make a test

The test project comes with a built in Test class.  Use that as the template for your tests.
the [TestFixture()] and [Test()] annotations are necessary.

The test class gets the [TestFixture()] annotation, and is traditionally named the same thing as the class it tests, with the word "Test" appended.

Test functions get the [Test()] annotation, and are public, void, and accept no params.
They are traditionally named "Test_FunctionName_HasBehavior"

Within a test function there are several "Assert" options that you use to test behavior.
Assert.AreEqual, Assert.Greater, Assert.Less, ... Assert.IsInstanceOfType
http://nunit.org/docs/2.2.10/assertions.html

## run your tests

If your test project is your startup project, you can run the tests by pressing the normal play button (or F5).

The results of your tests will show up down in the status bar under the "Test Results" button.  You can filter the list down to just the failed tests, or successful tests, or whatever.  You can expand each entry and see what assertion failed, and what values it received compared with what was expected.

Modify your classes code to fix the error (or fix the logic of your test if its wrong) and rerun the tests.  The tests keep you focused on finishing your code wihtout asking "what should I work on next".  Its simple, you work on whichever test isn't passing.  When they all pass, your class behaves as you expect.

## a quick note on validation

if your logic class contains your validation logic (like my example) then the UI still has to wrap that logic.  But the function in the UI area has no need to know what sorts of values are valid or invalid for a particular field,  Your validatin functions might look like this

```csharp
private void SomeControl_Validating(object sender, CancelEventArgs e)
{
	try
	{
		Desk.ValidateSomeField(SomeControl.Text);
		e.Cancel = false;
	}
	catch(Exception ex)
	{
		errorProvider1.SetError(SomeControl, ex.message);
		e.Cancel = true;
	}
}
```
