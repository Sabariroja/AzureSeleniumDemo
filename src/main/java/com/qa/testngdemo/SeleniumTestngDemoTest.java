package com.qa.testngdemo;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;

public class SeleniumTestngDemoTest extends BaseTest{
	@BeforeClass
	@Test(priority =1)
	public void verifySignInLink() {
		//verify the presence of sign In Link 
		driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
		if(driver.findElement(By.xpath("//a[contains(text(),'Sign in')]")).isDisplayed()){
			System.out.println("I'm here");
		}else {
			System.out.println("I'm not here");
		}	
	}
	@Test(priority = 2)
	public void verifyGoogleSearchbutton() {
		//Verify presence of Search button
		if(driver.findElement(By.name("q")).isDisplayed()){
			System.out.println("I'm here by Search btn");
		}else {
			System.out.println("I'm not here");
		}
	}
	

}
