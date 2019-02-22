import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DirectTweetMapper from './directTweetMapper';
import DirectTweetViewModel from './directTweetViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface DirectTweetCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface DirectTweetCreateComponentState {
  model?: DirectTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class DirectTweetCreateComponent extends React.Component<
  DirectTweetCreateComponentProps,
  DirectTweetCreateComponentState
> {
  state = {
    model: new DirectTweetViewModel(),
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
        let model = values as DirectTweetViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:DirectTweetViewModel) =>
  {  
    let mapper = new DirectTweetMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.DirectTweets,
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
            Api.DirectTweetClientRequestModel
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
              <label htmlFor='content'>content</label>
              <br />             
              {getFieldDecorator('content', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 140, message: 'Exceeds max length of 140' },
],
              
              })
              ( <Input placeholder={"content"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='date'>date</label>
              <br />             
              {getFieldDecorator('date', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='taggedUserId'>tagged_user_id</label>
              <br />             
              {getFieldDecorator('taggedUserId', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"tagged_user_id"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='time'>time</label>
              <br />             
              {getFieldDecorator('time', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"time"} /> )}
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

export const WrappedDirectTweetCreateComponent = Form.create({ name: 'DirectTweet Create' })(DirectTweetCreateComponent);

/*<Codenesium>
    <Hash>a9b94b5522d66b5d7492f22bb388be10</Hash>
</Codenesium>*/