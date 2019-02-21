import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
            loaded: false,
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
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>notes</h3>
              <p>{String(this.state.model!.note)}</p>
            </div>
            <div>
              <h3>primaryContactEmail</h3>
              <p>{String(this.state.model!.primaryContactEmail)}</p>
            </div>
            <div>
              <h3>primaryContactFirstName</h3>
              <p>{String(this.state.model!.primaryContactFirstName)}</p>
            </div>
            <div>
              <h3>primaryContactLastName</h3>
              <p>{String(this.state.model!.primaryContactLastName)}</p>
            </div>
            <div>
              <h3>primaryContactPhone</h3>
              <p>{String(this.state.model!.primaryContactPhone)}</p>
            </div>
          </div>
          {message}
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
    <Hash>811b721a39ee0616ad0190c39e476a02</Hash>
</Codenesium>*/