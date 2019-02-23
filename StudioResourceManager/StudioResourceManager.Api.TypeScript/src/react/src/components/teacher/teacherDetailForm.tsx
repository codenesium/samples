import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TeacherMapper from './teacherMapper';
import TeacherViewModel from './teacherViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {RateTableComponent} from '../shared/rateTable'
	



interface TeacherDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TeacherDetailComponentState {
  model?: TeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TeacherDetailComponent extends React.Component<
TeacherDetailComponentProps,
TeacherDetailComponentState
> {
  state = {
    model: new TeacherViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Teachers + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Teachers +
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
          let response = resp.data as Api.TeacherClientResponseModel;

          console.log(response);

          let mapper = new TeacherMapper();

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
							<h3>birthday</h3>
							<p>{String(this.state.model!.birthday)}</p>
						 </div>
					   						 <div>
							<h3>email</h3>
							<p>{String(this.state.model!.email)}</p>
						 </div>
					   						 <div>
							<h3>First Name</h3>
							<p>{String(this.state.model!.firstName)}</p>
						 </div>
					   						 <div>
							<h3>Last Name</h3>
							<p>{String(this.state.model!.lastName)}</p>
						 </div>
					   						 <div>
							<h3>phone</h3>
							<p>{String(this.state.model!.phone)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>userId</h3>
							<p>{String(this.state.model!.userIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Rates</h3>
            <RateTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Teachers + '/' + this.state.model!.id + '/' + ApiRoutes.Rates}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTeacherDetailComponent = Form.create({ name: 'Teacher Detail' })(
  TeacherDetailComponent
);

/*<Codenesium>
    <Hash>d8da578e271db5681231b08edec2c1d7</Hash>
</Codenesium>*/