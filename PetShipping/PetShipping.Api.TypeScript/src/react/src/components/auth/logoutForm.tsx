import React, { Component, FormEvent } from 'react';
import { Form,  Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface LogoutComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LogoutComponentState {
}

class LogoutComponent extends React.Component<
  LogoutComponentProps,
  LogoutComponentState
> {

  componentDidMount()
  {
     localStorage.setItem('authToken', '');
  }

  render() {
      return <Alert message={'You have been logged out...'} type='success' />;
  }
}

export const WrappedLogoutComponent = Form.create({
  name: 'Logout Form',
})(LogoutComponent);