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
    
    @State private var authType: AuthType = .login
    var body: some View {
        SegmentedView(authType: $authType)
        TopView()
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
                Text("login")
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
                            }
                        }
                    )
            }
        }
    }
}

#Preview {
    AuthView()
}
