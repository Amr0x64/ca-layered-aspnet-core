import React, {ReactElement, FC} from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import userManager, {loadUser, signinRedirect} from './auth/user-service';
import AuthProvider from './auth/auth-provider';
import SignInOidc from './auth/SignInOidc';
import SignOutOidc from './auth/SignoutOidc';
import NoteList from './notes/NoteList';

const App: FC<{}> = (): ReactElement => {
  loadUser();
  return (
    <div className="App">
      <header className="App-header">
        <button onClick={() => signinRedirect()}>Login</button>
        <AuthProvider userManager={userManager}>
          <Router>
            <Routes>
              <Route path="/" element={<NoteList/>} />
              <Route path="/signout-oidc" element={<SignOutOidc/>} />
              <Route path="/signin-oidc" element={<SignInOidc/>}/>
            </Routes>
          </Router>
        </AuthProvider>
      </header>
    </div>
  );
}

export default App;
