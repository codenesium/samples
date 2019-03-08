import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { StudentTableComponent } from '../shared/studentTable';

interface FamilyDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FamilyDetailComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class FamilyDetailComponent extends React.Component<
  FamilyDetailComponentProps,
  FamilyDetailComponentState
> {
  state = {
    model: new FamilyViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Families + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Families +
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
          let response = resp.data as Api.FamilyClientResponseModel;

          console.log(response);

          let mapper = new FamilyMapper();

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
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Note</h3>
              <p>{String(this.state.model!.note)}</p>
            </div>
            <div>
              <h3>Primary Contact Email</h3>
              <p>{String(this.state.model!.primaryContactEmail)}</p>
            </div>
            <div>
              <h3>Primary Contact First Name</h3>
              <p>{String(this.state.model!.primaryContactFirstName)}</p>
            </div>
            <div>
              <h3>Primary Contact Last Name</h3>
              <p>{String(this.state.model!.primaryContactLastName)}</p>
            </div>
            <div>
              <h3>Primary Contact Phone</h3>
              <p>{String(this.state.model!.primaryContactPhone)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Students</h3>
            <StudentTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Families +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Students
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedFamilyDetailComponent = Form.create({
  name: 'Family Detail',
})(FamilyDetailComponent);


/*<Codenesium>
    <Hash>f671e4f1409a20d62bc930d3c23f2c45</Hash>
</Codenesium>*/