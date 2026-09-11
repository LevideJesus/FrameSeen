import 'package:flutter/material.dart';

class LoginPage extends StatelessWidget {
  const LoginPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[300],
      body: SafeArea(
        child: Center(
        child: Column(
          children: [
            const SizedBox(height: 40,),
            Image.asset('lib/images/frameseen-logo.png', width: 300,)
          ],

        ),
        ),
        
      ),
    );
  }
}