import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface UserEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface UserEditComponentState {
  model?: UserViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class UserEditComponent extends React.Component<
  UserEditComponentProps,
  UserEditComponentState
> {
  state = {
    model: new UserViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

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

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as UserViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:UserViewModel) =>
  {  
    let mapper = new UserMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.state.model!.id,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.UserClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='aboutMe'>AboutMe</label>
              <br />             
              {getFieldDecorator('aboutMe', {
              rules:[],
              
              })
              ( <Input placeholder={"AboutMe"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='accountId'>AccountId</label>
              <br />             
              {getFieldDecorator('accountId', {
              rules:[],
              
              })
              ( <Input placeholder={"AccountId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='age'>Age</label>
              <br />             
              {getFieldDecorator('age', {
              rules:[],
              
              })
              ( <Input placeholder={"Age"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='creationDate'>CreationDate</label>
              <br />             
              {getFieldDecorator('creationDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"CreationDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='displayName'>DisplayName</label>
              <br />             
              {getFieldDecorator('displayName', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 40, message: 'Exceeds max length of 40' },
],
              
              })
              ( <Input placeholder={"DisplayName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='downVote'>DownVotes</label>
              <br />             
              {getFieldDecorator('downVote', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"DownVotes"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='emailHash'>EmailHash</label>
              <br />             
              {getFieldDecorator('emailHash', {
              rules:[{ max: 40, message: 'Exceeds max length of 40' },
],
              
              })
              ( <Input placeholder={"EmailHash"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='lastAccessDate'>LastAccessDate</label>
              <br />             
              {getFieldDecorator('lastAccessDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"LastAccessDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='location'>Location</label>
              <br />             
              {getFieldDecorator('location', {
              rules:[{ max: 100, message: 'Exceeds max length of 100' },
],
              
              })
              ( <Input placeholder={"Location"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='reputation'>Reputation</label>
              <br />             
              {getFieldDecorator('reputation', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Reputation"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='upVote'>UpVotes</label>
              <br />             
              {getFieldDecorator('upVote', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"UpVotes"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='view'>Views</label>
              <br />             
              {getFieldDecorator('view', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Views"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='websiteUrl'>WebsiteUrl</label>
              <br />             
              {getFieldDecorator('websiteUrl', {
              rules:[{ max: 200, message: 'Exceeds max length of 200' },
],
              
              })
              ( <Input placeholder={"WebsiteUrl"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedUserEditComponent = Form.create({ name: 'User Edit' })(UserEditComponent);

/*<Codenesium>
    <Hash>970886091ac951d4533e2573533c69c9</Hash>
</Codenesium>*/