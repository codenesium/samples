import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FollowingMapper from './followingMapper';
import FollowingViewModel from './followingViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface FollowingCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface FollowingCreateComponentState {
  model?: FollowingViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class FollowingCreateComponent extends React.Component<
  FollowingCreateComponentProps,
  FollowingCreateComponentState
> {
  state = {
    model: new FollowingViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as FollowingViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:FollowingViewModel) =>
  {  
    let mapper = new FollowingMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Followings,
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
            Api.FollowingClientRequestModel
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
              <label htmlFor='dateFollowed'>date_followed</label>
              <br />             
              {getFieldDecorator('dateFollowed', {
              rules:[],
              
              })
              ( <Input placeholder={"date_followed"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='muted'>muted</label>
              <br />             
              {getFieldDecorator('muted', {
              rules:[{ max: 1, message: 'Exceeds max length of 1' },
],
              
              })
              ( <Input placeholder={"muted"} /> )}
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

export const WrappedFollowingCreateComponent = Form.create({ name: 'Following Create' })(FollowingCreateComponent);

/*<Codenesium>
    <Hash>3d8701ab95a4c9a90906259c96835251</Hash>
</Codenesium>*/