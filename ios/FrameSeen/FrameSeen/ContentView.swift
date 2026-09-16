//
//  ContentView.swift
//  FrameSeen
//
//  Created by Levi de Jesus da Silva Francelino on 12/09/26.
//

import SwiftUI

enum AuthType{
    case login
    case register
}

struct AuthView: View {
    @Environment(\.colorScheme) private var colorScheme
    
    @State private var email: String = ""
    @State private var password: String = ""
    
    @FocusState private var isEmailFocused
    @FocusState private var isPassFocused
    
    @State private var showPass = false
    
    
    
    @State private var authType: AuthType = .login
    var body: some View {
        TopView()
        SegmentedView(authType: $authType)
        
        
        VStack(spacing: 15){
            TextField(text: $email){
                Text("Email")
            }
            .focused($isEmailFocused)
            ZStack{
                
                TextField(text: $password){
                    Text("Password")
                }
                .focused($isPassFocused)
                .overlay(content:{
                    Button {
                        withAnimation{
                            showPass.toggle()
                        }
                    } label:{
                        
                    }
                })
                .opacity(showPass ? 1 : 0)
                .zIndex(1)
                
                SecureField(text: $password){
                    Text("Password")
                }
                .focused($isPassFocused)
            }
        }
    }
    
    struct TopView: View {
        var body: some View {
            VStack(alignment: .center) {
                Image("logo.frame.seen")
                    .resizable()
                    .aspectRatio(contentMode: .fit )
                    .frame(width: 75)
                
                Text("FrameSeen")
                    .font(.system(size: 35, weight: .bold, design: .rounded))
            }
        }
    }
    
    struct SegmentedView: View{
        @Environment(\.colorScheme) private var colorScheme
        @Binding var authType: AuthType
        
        var body: some View{
            HStack(spacing:0){
                Button {
                    withAnimation{
                        authType = .login
                    }
                } label: {
                    Text("Login")
                        .fontWeight(authType == .login ? .semibold : .regular)
                        .foregroundColor(authType == .login ? (colorScheme == .light ? .black : .white) : .gray)
                        .padding(.vertical, 12)
                        .padding(.horizontal, authType == .login ? 30 : 20)
                        .background(
                            ZStack{
                                if authType == .login {
                                    RoundedRectangle(cornerRadius: 20)
                                        .stroke(Color.black.opacity(0.3),
                                                lineWidth: 0.5)
                                        .zIndex(1)
                                }
                                
                                RoundedRectangle(cornerRadius: 20)
                                    .fill(authType == .login ?
                                          Color(UIColor.systemGray5):
                                            Color(UIColor.systemGray6))
                                    .zIndex(0)
                                
                            }
                        )
                }
                
                Button {
                    withAnimation{
                        authType = .register
                    }
                } label: {
                    Text("Register")
                        .fontWeight(authType == .register ? .semibold : .regular)
                        .foregroundColor(authType == .register ? (colorScheme == .light ? .black : .white) : .gray)
                        .padding(.vertical, 12)
                        .padding(.horizontal, authType == .register ? 30 : 20)
                        .background(
                            ZStack{
                                if authType == .register {
                                    RoundedRectangle(cornerRadius: 20)
                                        .stroke(Color.black.opacity(0.3),
                                                lineWidth: 0.5)
                                        .zIndex(1)
                                }
                                
                                RoundedRectangle(cornerRadius: 20)
                                    .fill(authType == .register ?
                                          Color(UIColor.systemGray5):
                                            Color(UIColor.systemGray6))
                                    .zIndex(0)
                                
                            }
                        )
                }
            }
            
            .background(
                Color(UIColor.systemGray6)
            )
            .cornerRadius(20)
            .padding(.horizontal, 20)
            .padding(.bottom, 10)
            .frame(maxWidth: . infinity)
        }
    }
    
    
}
#Preview {
    AuthView()
}
