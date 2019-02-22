import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {AdminTableComponent} from '../shared/adminTable'
	import {StudentTableComponent} from '../shared/studentTable'
	import {TeacherTableComponent} from '../shared/teacherTable'
	



interface UserDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UserDetailComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UserDetailComponent extends React.Component<
UserDetailComponentProps,
UserDetailComponentState
> {
  state = {
    model: new UserViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Users + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Users +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.UserClientResponseModel;

          console.log(response);

          let mapper = new UserMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>password</h3>
							<p>{String(this.state.model!.password)}</p>
						 </div>
					   						 <div>
							<h3>username</h3>
							<p>{String(this.state.model!.username)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Admins</h3>
            <AdminTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.Admins}
			/>
         </div>
			 <div>
            <h3>Students</h3>
            <StudentTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.Students}
			/>
         </div>
			 <div>
            <h3>Teachers</h3>
            <TeacherTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id + '/' + ApiRoutes.Teachers}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedUserDetailComponent = Form.create({ name: 'User Detail' })(
  UserDetailComponent
);

/*<Codenesium>
    <Hash>4578898598273ee891b6a1e5101594cc</Hash>
</Codenesium>*/