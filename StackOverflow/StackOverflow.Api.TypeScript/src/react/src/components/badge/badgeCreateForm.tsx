import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BadgeMapper from './badgeMapper';
import BadgeViewModel from './badgeViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface BadgeCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface BadgeCreateComponentState {
  model?: BadgeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class BadgeCreateComponent extends React.Component<
  BadgeCreateComponentProps,
  BadgeCreateComponentState
> {
  state = {
    model: new BadgeViewModel(),
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
        let model = values as BadgeViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:BadgeViewModel) =>
  {  
    let mapper = new BadgeMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Badges,
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
            Api.BadgeClientRequestModel
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
              <label htmlFor='date'>Date</label>
              <br />             
              {getFieldDecorator('date', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>Name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ max: 40, message: 'Exceeds max length of 40' },
],
              
              })
              ( <Input placeholder={"Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userId'>UserId</label>
              <br />             
              {getFieldDecorator('userId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"UserId"} /> )}
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

export const WrappedBadgeCreateComponent = Form.create({ name: 'Badge Create' })(BadgeCreateComponent);

/*<Codenesium>
    <Hash>d016fb9ec6570f2aa502bdd963113d53</Hash>
</Codenesium>*/